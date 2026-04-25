using System;

namespace AccessModifierLibrary
{
    public class Demo
    {
        public int publicVar = 10;
        private int privateVar = 20;
        internal int internalVar = 30;
        protected int protectedVar = 40;
        protected internal int protectedInternalVar = 50;

        public void Show()
        {
            Console.WriteLine("Inside Demo Class:");
            Console.WriteLine(publicVar);
            Console.WriteLine(privateVar);
            Console.WriteLine(internalVar);
            Console.WriteLine(protectedVar);
            Console.WriteLine(protectedInternalVar);
        }
    }

    public class Child : Demo
    {
        public void Display()
        {
            Console.WriteLine("Inside Child Class : ");
            Console.WriteLine(publicVar);
            Console.WriteLine(protectedVar);
            Console.WriteLine(protectedInternalVar);
        }
    }
}