﻿using BenchmarkDotNet.Running;
using Benchmarks;

BenchmarkRunner.Run<FirstOperatorBenchmark>();
BenchmarkRunner.Run<LastOperatorBenchmark>();
BenchmarkRunner.Run<SingleOperatorBenchmark>();
