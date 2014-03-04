using System;
using System.Threading;
namespace Server
{
	public class Printer
	{
		private Job current;
		private PrinterPool pool;
		private ManualResetEvent hasJobsEvent;
		public Printer ()
		{
		}
		public void setPool(PrinterPool pool) 
		{
			this.pool = pool;
		}
		public void work ()
		{
			hasJobsEvent = pool.getEventHasJob ();
			while (true) {
				hasJobsEvent.WaitOne ();
				Job job = pool.getFile ().getNextJob ();
				if (job != null) {
					doJob (job);
				}
			}
		}
		private void doJob (Job job)
		{
			System.Console.WriteLine (job.path);
			Thread.Sleep (1000);
		}
	}
}

