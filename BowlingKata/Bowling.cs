using System.Collections.Generic;
using System.Linq;

namespace BowlingKata
{
	public class Bowling
	{
		private readonly int[] _rolls = new int[21];
		private int _idxOfNextFrame;
		private int _rollIndex;

		public void Roll(int pins)
		{
			_rolls[_rollIndex++] = pins;
		}

		private IEnumerable<int> CalculateFrameScore()
		{
			var frames = new int[10];
			for (var i = 0; i < frames.Length; i++)
			{
				if (IsSpare(_idxOfNextFrame))
				{
					frames[i] = SpareScore();
					_idxOfNextFrame += 2;
				}
				else if (IsStrike(_idxOfNextFrame))
				{
					frames[i] = StrikeScore();
					_idxOfNextFrame++;
				}
				else
				{
					frames[i] = NormalScore();
					_idxOfNextFrame += 2;
				}
			}

			return frames;
		}

		private int NormalScore()
		{
			return _rolls[_idxOfNextFrame] + _rolls[_idxOfNextFrame + 1];
		}

		private int StrikeScore()
		{
			return 10 + _rolls[_idxOfNextFrame + 1] + _rolls[_idxOfNextFrame + 2];
		}

		private int SpareScore()
		{
			return _rolls[_idxOfNextFrame] + _rolls[_idxOfNextFrame + 1] + _rolls[_idxOfNextFrame + 2];
		}

		public int Score()
		{
			var frames = CalculateFrameScore();
			return frames.Sum();
		}

		private bool IsSpare(int frameIndex)
		{
			return _rolls[frameIndex] + _rolls[frameIndex + 1] == 10;
		}

		private bool IsStrike(int frameIndex)
		{
			return _rolls[frameIndex] == 10;
		}
	}
}