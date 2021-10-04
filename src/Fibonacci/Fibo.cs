using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fibonacci {
    public static class Compute {
        public static async Task<IList<int>> ExecuteAsync(string[] args) {
            var result = new List<int>();
            var tasks = RunFibonaccis(args);

            foreach (var task in tasks)
            {
                var resultAwaited = await task;
                result.Add(resultAwaited);
            }

            return result;
        }
        private static List<Task<int>> RunFibonaccis(string[] args)
        {
            int Fib(int i) =>
                i switch
                {
                    int when i <= 2 => 1,
                    _ => Fib(i - 2) + Fib(i - 1)
                };

            var tasks = new List<Task<int>>();
            
            foreach (var input in args)
            {
                var task = Task.Run(() => Fib(Convert.ToInt32(input)));
                tasks.Add(task);
            }

            return tasks;
        }
    }
}