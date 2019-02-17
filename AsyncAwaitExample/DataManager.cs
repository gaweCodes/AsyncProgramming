using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitExample
{
    internal class DataManager
    {
        /**
        * Maybe it is better if the use cannot start this new threads directly, so I do this Factory.StartNew inside the loading functions.
         * In .NET 4.5 >= you can use async ans await.
        */
        public async Task<List<string>> LoadSpeakersAsync()
        {
            
            var task = Task.Factory.StartNew(() =>
            {
                var speakersList = new List<string>();
                /**
                 * You could also work with yield return here. But this doesn't work with async programming.
                 * I do this Thread sleep to simulate a real "API-Connection"
                 */
                for (var index = 0; index < 10; index++)
                {
                    Thread.Sleep(500);
                    speakersList.Add("Speaker No. " + index);
                }

                return speakersList;
            });
            return await task;
        }

        /**
        * Same here
        */
        public async Task<List<string>> LoadSessionsAsync()
        {
            /**
            * You could also work with yield return here. But this doesn't work with async programming.
            * I do this Thread sleep to simulate a real "API-Connection"
            */
            var task = Task.Factory.StartNew(() => {
                Thread.Sleep(3000);
                var speakersList = new List<string>();
                for (var index = 0; index < 10; index++)
                    speakersList.Add("session No. " + index);
                return speakersList;
            });
            return await task;
        }

        public async Task LogSomethingAsync(string loggingText)
        {
            using (var sw = new StreamWriter("log.txt"))
                await sw.WriteAsync(loggingText);
        }
    }
}
