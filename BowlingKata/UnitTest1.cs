using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingKata
{
	[TestClass]
	public class BowlingTests
	{
		private Bowling _bowling = new Bowling();

		[TestMethod]
		public void Roll_0_score_0()
		{
			ScoreShouldBe(0);
		}

		[TestMethod]
		public void Roll_1_score_1()
		{
			_bowling.Roll(1);
			ScoreShouldBe(1);
		}

		[TestMethod]
		public void Roll_111_score_3()
		{
			RollMany(3, 1);
			ScoreShouldBe(3);
		}

		[TestMethod]
		public void Roll_111_frame_2()
		{
			RollMany(3, 1);
			FrameShouldBe(2);
		}

		[TestMethod]
		public void Roll_111_frameScore_2()
		{
			RollMany(3, 1);
			ScoreOfFirstFrameShouldBe(2);
		}

		[TestMethod]
		public void Roll_222_frameScore_4()
		{
			RollMany(3, 2);
			ScoreOfFirstFrameShouldBe(4);
		}

		[TestMethod]
		public void Roll_555_frameScore_15()
		{
			RollMany(3, 5);
			ScoreOfFirstFrameShouldBe(15);
		}

		[TestMethod]
		public void Roll_5555_frameScore_15()
		{
			RollMany(4, 5);
			ScoreOfFirstFrameShouldBe(15);
		}

		[TestMethod]
		public void Roll_Strike_twice_frame_should_be_3()
		{
			_bowling.Roll(10);
			_bowling.Roll(10);
			FrameShouldBe(3);
		}

		[TestMethod]
		public void Roll_11_after_Strike_frameScore_should_be_12()
		{
			_bowling.Roll(10);
			_bowling.Roll(1);
			_bowling.Roll(1);
			ScoreOfFirstFrameShouldBe(12);
		}

		[TestMethod]
		public void Roll_all_5_score_should_be_150()
		{
			RollMany(21, 5);
			ScoreShouldBe(150);
		}

		[TestMethod]
		public void Roll_all_strike_score_should_be_300()
		{
			RollMany(12, 10);
			ScoreShouldBe(300);
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
			ScoreShouldBe(133);
		}

		private void ScoreOfFirstFrameShouldBe(int expected)
		{
			Assert.AreEqual(expected, _bowling.ScoreOfFrame(1));
		}

		private void FrameShouldBe(int expected)
		{
			Assert.AreEqual(expected, _bowling.Frame);
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