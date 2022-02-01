using System;

namespace LearningCS.Resources.TaskClasses.BottleMath
{
    internal class Bottle
    {
        public int Capacity { get; }
        public int Content { get; private set; }

        public Bottle(int capacity)
        {
            Capacity = capacity;
        }

        public void FillAllTheWay()
        {
            Content = Capacity;
        }

        public void Fill(int volume)
        {
            Content = Math.Min(Content + volume, Capacity);
        }

        public int Empty()
        {
            var content = Content;
            Content = 0;
            return content;
        }

        public void TransferContent(Bottle bottle)
        {
            var capacity = Capacity - Content;
            var fillAmount = Math.Min(capacity, bottle.Content);
            Content += fillAmount;
            bottle.Content -= fillAmount;
        }
    }
}
