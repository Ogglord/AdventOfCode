using System;
using AoCHelper;
using Xunit.Abstractions;

namespace AdventOf.Test
{
	public class TestHelperFixture : IDisposable
	{
		InputDownloader inputDownloader;

		public TestHelperFixture()
		{
            string sessionId = "53616c7465645f5fe489f3bd2a5d7da82f055f40dedb6512abd72a9c90ca417bb1149043a427a9bd43c90632648bb3a8ba5a0566e306f27b2c42b60ba4de9d7e";
            inputDownloader = new InputDownloader(sessionId);
        }

        public async Task<string> GetInput(int day, int year)
        {
            return await inputDownloader.GetInput(day, year);
        }

        public void Dispose()
        {
            
        }
    }
}

