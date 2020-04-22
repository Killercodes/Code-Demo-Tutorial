# C# BruteForce.md

This brute force algorithm was originally written (by me) back in 1998, and has been collecting dust 
since then. However, for the purpose of testing Gist on GitHub I decided to rewrite the algorithm 
from VB6 to C#, make some improvements and release this fast, compact, non-recursive, brute force 
algorithm under the MIT license: http://opensource.org/licenses/MIT

Notes:
- Do a run with testLetters = "0123456789" and testLength = 3, to see what happens
- Remember to keep the callback testCalback as fast as possible
- Tweet some love to @fredrikdev :)

Have fun!
Fredrik
https://github.com/johanssonrobotics

```cs
using System;

namespace FJR {
	public static class Algorithm {
		// callback that is called for every combination to test
		public delegate bool BruteForceTest(ref char[] test, int testIndex, int testMax);

		// fast, compact, non-recursive, brute force algorithm
		public static bool BruteForce(string testLetters, int testLength, BruteForceTest testCallback) {
			// get the number of combinations we need to try (just for statistic purposes)
			int testIndex = 0, testMax = (int)Math.Pow(testLetters.Length, testLength);

			// initialize & perform first test
			var test = new char[testLength];
			for (int x = 0; x < testLength; x++) 
				test[x] = testLetters[0];
			if (testCallback(ref test, ++testIndex, testMax))
				return true;

			// start rotating chars from the back and forward
			for (int ti = testLength - 1, li = 0; ti > -1; ti--) {
				for (li = testLetters.IndexOf(test[ti]) + 1; li < testLetters.Length; li++) {
					// test
					test[ti] = testLetters[li];
					if (testCallback(ref test, ++testIndex, testMax))
						return true;

					// rotate to the right
					for (int z = ti + 1; z < testLength; z++)
						if (test[z] != testLetters[testLetters.Length - 1]) {
							ti = testLength;
							goto outerBreak;
						}
				}
				outerBreak:
				if (li == testLetters.Length) 
					test[ti] = testLetters[0];
			}

			// no match
			return false;
		}

		public static void Main(string[] args) {
			// example usage
			Console.WriteLine("Searching for combination...");

			// our 'test' routine that gets called for every combination to test
			BruteForceTest testCallback = delegate(ref char[] test, int testIndex, int testMax) {
				var str = new string(test);

				// write the test string and how far we've come
				Console.WriteLine(str + "\t" + Math.Round(100 * (testIndex / (double)testMax), 0) + "%");

				// return true to cancel further testing (e.g. on a match as below on 'bba')
				return (str == "bba");
			};

			// test all combinations of the letters "abc" with the result length 3
			// todo: you may want to add a for-loop here to test e.g. length 1 to 8
			if (BruteForce("abc", 3, testCallback)) {
				Console.WriteLine("Success! Combination found!");
			} else {
				Console.WriteLine("Failure! Combination not found!");
			}

			Console.ReadLine();
		}
	}
}
```
