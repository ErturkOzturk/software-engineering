public class ClassToLock { }
volatile ClassToLock? _classToLock;
readonly object _classLock = new();

public ClassToLock myClass
{
    get
    {
        if (_classToLock == null)             // First check (outside lock)
            lock (_classLock)
                if (_classToLock == null)         // Second check (inside lock)
                    _classToLock = new ClassToLock();
        return _classToLock;
    }
}
