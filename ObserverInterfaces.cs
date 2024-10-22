using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLearningApp
{
    public interface ISubject<T>
    {
        public void Attach(IMyObserver<T> observer);
        public void Detach(IMyObserver<T> observer);
        public void Notify();
    }

    public interface IMyObserver<T>
    {
        public void Update(T subject);
    }
}
