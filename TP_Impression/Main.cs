using System;

namespace Server
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			PrinterPool pool = new PrinterPool ();
            Server server = new Server(pool);
			for(int i=0;i<50;++i)
				pool.add (new Printer ());
			
			Job lastJob = null;
			for (int i=0; i<50; ++i) {
				Job job = new Job (string.Format ("coucou {0}", i));
				lastJob = job;
				pool.getFile ().add (job);
			}
			pool.getFile ().remove (lastJob);
		}
	}
}
