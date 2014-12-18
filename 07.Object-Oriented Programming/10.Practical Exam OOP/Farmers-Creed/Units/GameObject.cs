namespace FarmersCreed.Units
{
    using System;

    public abstract class GameObject
    {
        private string id;

        public GameObject(string id)
        {
            this.Id = id;
        }

        public string Id
        {
            get { return this.id; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Object id cannot be null!");
                }

                this.id = value;
            }
        }

        public override string ToString()
        {
            return String.Format("--{0} {1}", this.GetType().Name, this.id);
        }
    }
}
