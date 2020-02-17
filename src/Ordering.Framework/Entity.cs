namespace Ordering.Framework
{
    public abstract class Entity
    {
        //TODO: Fill this out.

        int _Id;
        public virtual int Id
        {
            get
            {
                return _Id;
            }
            protected set
            {
                _Id = value;
            }
        }
    }
}
