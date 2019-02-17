using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncAwaitExample
{
    public partial class ExampleForm : Form
    {
        public ExampleForm()
        {
            InitializeComponent();
        }

        //For .NET >= 4.5 you need to set the async keyword in the signature of the function.
        private async void BtnLoadData_Click(object sender, EventArgs e)
        {
            /**
             * To check out duration of this function I create a stop watch.
             */
            var watch = new Stopwatch();
            watch.Start();

            var manager = new DataManager();

            #region .NET >= 4.5
            //LoadSpeakersAsync returns now a List of strings, not a task of a list of strings.
            //Step 1: var loadSpeakersList = await manager.LoadSpeakersAsync();
            //Step 1: var loadSessionsList = await manager.LoadSessionsAsync();
            var loadSpeakersList = manager.LoadSpeakersAsync();
            var loadSessionsList = manager.LoadSessionsAsync();
            
            //Step 2:
            LstSpeakers.DataSource = await loadSpeakersList;
            LstSessions.DataSource = await loadSessionsList;
            /**
             * Results:
             * Step 1: 8.01 seconds. Why? What I've done?! Look at step 2.
             * Step 2: 5 seconds. Because you await onely once or better you await at latest possible time.
             */
            #endregion

            #region .NET 4.0
            /*
            var loadSpeakersList = manager.LoadSpeakersAsync();
            var loadSessionsList = manager.LoadSessionsAsync();

            //With this approach it is possible to do a task and then do another. Of course also async.
            loadSpeakersList.ContinueWith(speakerTask => MessageBox.Show(speakerTask.Result.Count + " speaker loaded"));

            //Step 4: There is no change in the duration time. Because the tasks work parallel.
            Thread.Sleep(4000);
            //It is not necessary to do the Task.WaitAll because the .Result does it automatically.
            LstSpeakers.DataSource = loadSpeakersList.Result;
            LstSessions.DataSource = loadSessionsList.Result;
            /**
             * Step 2:
             * Do the logic in a separate thread. Task.Factory.StartNew return an Task<TResult> TResult == List<string>.
            * So it is: Task<List<string>>
            var loadSpeakersList = Task.Factory.StartNew(() => manager.LoadSpeakers());
            var loadSessionsList = Task.Factory.StartNew(() => manager.LoadSessions());

            * Wait until both requests finished.
            Task.WaitAll(loadSpeakersList, loadSessionsList);
            
            LstSpeakers.DataSource = loadSpeakersList.Result;
            LstSessions.DataSource = loadSessionsList.Result;
            * Step 1: Synchronous way: LstSpeakers.DataSource = manager.LoadSpeakers();
            * Step 1: Synchronous way:LstSessions.DataSource = manager.LoadSessions();
            **/
            /**
             * Results .NET 4.0:
             * 1. Step: Synchronous 8.01 seconds. So the both functions run one after the other. 10*0.5 = 5 seconds + 3 seconds from sessions.
             * 2. Step: Separate Threads or better Tasks: 5.026 seconds. So the tasks run parallel.
             * 3. Step: Outsourced changes of step 2: 5.026 seconds. So the tasks run parallel.
             * 4. Step: 5.026 seconds. You load data from server and do something else in the same time.
             */
            #endregion

            watch.Stop();

            await manager.LogSomethingAsync(watch.ElapsedMilliseconds / 1000.0 + " seconds");
            //It works because LogSomething return not void it returns a Task.
            Process.Start("log.txt");
        }
    }
}
