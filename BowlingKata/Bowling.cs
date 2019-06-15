using System;

namespace BowlingKata
{
	public class Bowling
	{
		private readonly Frame _frame = new Frame();
		private int _currentFrame = 1;
		private bool _firstThrow = true;
		private int _rollIdx;

		public int CurrentFrame
		{
			get => _currentFrame >= 10 ? 10 : _currentFrame;
			set => _currentFrame = value;
		}

		public int Score()
		{
			var score = ScoreOfFrame(CurrentFrame);
			Console.WriteLine(score);
			return score;
		}

		public int ScoreOfFrame(int currentFrame)
		{
			return _frame.ScoreOfFrame(currentFrame);
		}

		public void Roll(int pins)
		{
			AdjustCurrentFrame(pins);
			_frame.Roll(_rollIdx++, pins);
		}

		private void AdjustCurrentFrame(int pins)
		{
			if (_firstThrow)
			{
				if (pins == 10)
				{
					GotoNextFrame();
				}
				else
				{
					_firstThrow = false;
				}
			}
			else
			{
				_firstThrow = true;
				GotoNextFrame();
			}
		}

		private void GotoNextFrame()
		{
			Console.WriteLine(_frame.ScoreOfFrame(CurrentFrame));
			_currentFrame++;
		}
	}
}