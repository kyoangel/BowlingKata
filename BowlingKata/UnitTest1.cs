using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingKata
{
	[TestClass]
	public class BowlingTests
	{
		[TestMethod]
		public void no_roll_score_0()
		{
			var bowling = new Bowling();
			var score = bowling.Score();
			Assert.AreEqual(0, score);
		}
	}
}