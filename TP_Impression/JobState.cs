using System;
namespace Server
{
	public struct JobState
	{
		public int progress;
		public enum State {
			PENDING,
			PRINTING
		};
		public State state;
	}
}

