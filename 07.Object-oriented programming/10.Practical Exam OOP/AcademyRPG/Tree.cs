using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public class Tree : StaticObject, IResource
    {
        protected int Size { get; private set; }

        public ResourceType Type 
        { 
            get 
            { 
                return ResourceType.Lumber; 
            } 
        }

        public int Quantity
        {
            get
            {
                return this.Size;
            }
        }

        public Tree(int size, Point position)
            : base(position)
        {
            this.Size = size;
            this.HitPoints = size;
        }
    }
}
