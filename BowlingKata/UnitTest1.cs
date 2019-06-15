using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingKata
{
	[TestClass]
	public class BowlingTests
	{
		private Bowling _bowling = new Bowling();

		[TestMethod]
		public void no_roll_score_0()
		{
			ScoreShouldBe(0);
		}

		[TestMethod]
		public void roll_1_score_1()
		{
			_bowling.Roll(1);
			TheResultShouldBe(1, 1, 1);
		}

		[TestMethod]
		public void roll_111_score_3()
		{
			RollMany(3, 1);
			TheResultShouldBe(2, 2, 3);
		}

		[TestMethod]
		public void roll_spare_then_5_score_20()
		{
			RollMany(3, 5);
			TheResultShouldBe(2, 15, 20);
		}

		[TestMethod]
		public void roll_strike_then_5_score_20()
		{
			GivenStrike();
			_bowling.Roll(5);
			TheResultShouldBe(2, 15, 20);
		}

		[TestMethod]
		public void roll_strike_then_0_5_score_20()
		{
			GivenStrike();
			_bowling.Roll(0);
			_bowling.Roll(5);
			TheResultShouldBe(3, 15, 20);
		}

		[TestMethod]
		public void roll_all_spare_score_150()
		{
			RollMany(21, 5);
			TheResultShouldBe(10, 15, 150);
		}

		[TestMethod]
		public void roll_all_strike_score_300()
		{
			RollMany(12, 10);
			TheResultShouldBe(10, 30, 300);
		}

		[TestMethod]
		public void roll_all_9_0_score_90()
		{
			for (int i = 0; i < 10; i++)
			{
				_bowling.Roll(9);
				_bowling.Roll(0);
			}
			TheResultShouldBe(10, 9, 90);
		}

		[TestMethod]
		public void Sample_All_cases()
		{
			_bowling.Roll(1);
			_bowling.Roll(4);
			_bowling.Roll(4);
			_bowling.Roll(5);
			_bowling.Roll(6);
			_bowling.Roll(4);
			_bowling.Roll(5);
			_bowling.Roll(5);
			_bowling.Roll(10);
			_bowling.Roll(0);
			_bowling.Roll(1);
			_bowling.Roll(7);
			_bowling.Roll(3);
			_bowling.Roll(6);
			_bowling.Roll(4);
			_bowling.Roll(10);
			_bowling.Roll(2);
			_bowling.Roll(8);
			_bowling.Roll(6);
			TheResultShouldBe(10, 5, 133);
		}

		private void GivenStrike()
		{
			_bowling.Roll(10);
		}

		private void TheResultShouldBe(int currentFrame, int firstFrameScore, int totalScore)
		{
			CurrentFrameShouldBe(currentFrame);
			FirstFrameScoreShouldBe(firstFrameScore);
			ScoreShouldBe(totalScore);
		}

		private void RollMany(int rolls, int pinsPerRoll)
		{
			for (int i = 0; i < rolls; i++)
			{
				_bowling.Roll(pinsPerRoll);
			}
		}

		private void CurrentFrameShouldBe(int expected)
		{
			Assert.AreEqual(expected, _bowling.CurrentFrame);
		}

		private void FirstFrameScoreShouldBe(int expected)
		{
			Assert.AreEqual(expected, _bowling.ScoreOfFrame(1));
		}

		private void ScoreShouldBe(int expected)
		{
			var score = _bowling.Score();
			Assert.AreEqual(expected, score);
		}
	}
}