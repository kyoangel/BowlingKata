using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingKata
{
	[TestClass]
	public class BowlingTests
	{
		private readonly Bowling _bowling = new Bowling();

		[TestMethod]
		public void no_roll_score_zero()
		{
			ScoreShouldBe(0);
		}

		[TestMethod]
		public void roll_all_one_score_20()
		{
			RollMany(20, 1);
			ScoreShouldBe(20);
		}

		[TestMethod]
		public void roll_spare_then_one_score_12()
		{
			_bowling.Roll(5);
			_bowling.Roll(5);
			_bowling.Roll(1);
			RollMany(17, 0);
			ScoreShouldBe(12);
		}

		[TestMethod]
		public void strike_then_1_score_12()
		{
			_bowling.Roll(10);
			_bowling.Roll(1);
			RollMany(18, 0);
			ScoreShouldBe(12);
		}

		[TestMethod]
		public void strike_then_1_then_1_score_14()
		{
			_bowling.Roll(10);
			_bowling.Roll(1);
			_bowling.Roll(1);
			RollMany(17, 0);
			ScoreShouldBe(14);
		}

		[TestMethod]
		public void Suggested_test_case_all_9_0()
		{
			for (var i = 0; i < 10; i++)
			{
				_bowling.Roll(9);
				_bowling.Roll(0);
			}
			ScoreShouldBe(90);
		}

		[TestMethod]
		public void all_file_score_150()
		{
			RollMany(21, 5);
			ScoreShouldBe(150);
		}

		[TestMethod]
		public void all_strike_score_300()
		{
			RollMany(12, 10);
			ScoreShouldBe(300);
		}

		private void RollMany(int rolls, int pinsPerRoll)
		{
			for (var i = 0; i < rolls; i++)
			{
				_bowling.Roll(pinsPerRoll);
			}
		}

		private void ScoreShouldBe(int expected)
		{
			var score = _bowling.Score();
			Assert.AreEqual(expected, score);
		}
	}
}