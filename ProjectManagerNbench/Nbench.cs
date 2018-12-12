using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBench;

namespace ProjectManagerNbench
{
    public class Nbench
    {
        private Counter _opcounter;
        [PerfSetup]
        public void SetUp(BenchmarkContext context)
        {
            _opcounter = context.GetCounter("MyCounter");
        }
        [PerfBenchmark(NumberOfIterations = 13, RunMode = RunMode.Throughput, RunTimeMilliseconds = 1000, TestMode = TestMode.Measurement)]
        [CounterMeasurement("MyCounter")]
        [MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
        public void benchmarkmethod(BenchmarkContext context)
        {
            var bytes = new byte[1024];
            _opcounter.Increment();
        }
    }
}
