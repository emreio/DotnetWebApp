using System;


namespace EmreDotnetTest
{
    public class A
    {
		//Comments
        protected virtual void M1() { }
        void M2() { }
    }

	//some comment
    public class B : A
    {
        override M1() { }
        new M2() { }
    }
}