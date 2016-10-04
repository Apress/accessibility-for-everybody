using System;
using NUnit.Framework;

namespace NUnitDemo
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class MathCheck
	{
      /// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
         string   Value1Input;
         string   Value2Input;
         string   ResultOutput;

         // Get some input.
         Console.Write("Type the first input value: ");
         Value1Input = Console.ReadLine();
         Console.Write("Type the second input value: ");
         Value2Input = Console.ReadLine();

         // Perform the add operation.
         ResultOutput = DoAdd(Value1Input, Value2Input);
         Console.WriteLine("The Add Ouput is: {0}", ResultOutput);

         // Perform the subtract operation.
         ResultOutput = DoSubtract(Value1Input, Value2Input);
         Console.WriteLine("The Subtract Ouput is: {0}", ResultOutput);

         // Perform the multiply operation.
         ResultOutput = DoMultiply(Value1Input, Value2Input);
         Console.WriteLine("The Multiply Ouput is: {0}", ResultOutput);

         // Perform the divide operation.
         ResultOutput = DoDivide(Value1Input, Value2Input);
         Console.WriteLine("The Divide Ouput is: {0}", ResultOutput);

         // Wait for the user to press Enter.
         Console.Write("Press any key when ready...");
         Console.ReadLine();
		}

      public static string DoAdd(string Input1, string Input2)
      {
         int   Value1;
         int   Value2;
         int   Result;

         // Convert the strings.
         Value1 = Int32.Parse(Input1);
         Value2 = Int32.Parse(Input2);

         // Perform the addition.
         Result = Value1 + Value2;

         // Output the result.
         return Result.ToString();
      }

      public static string DoSubtract(string Input1, string Input2)
      {
         int   Value1;
         int   Value2;
         int   Result;

         // Convert the strings.
         Value1 = Int32.Parse(Input1);
         Value2 = Int32.Parse(Input2);

         // Perform the addition.
         Result = Value2 - Value1;

         // Output the result.
         return Result.ToString();
      }

      public static string DoMultiply(string Input1, string Input2)
      {
         int   Value1;
         int   Value2;
         int   Result;

         // Convert the strings.
         Value1 = Int32.Parse(Input1);
         Value2 = Int32.Parse(Input2);

         // Perform the addition.
         Result = Value1 * Value2;

         // Output the result.
         return Result.ToString();
      }

      public static string DoDivide(string Input1, string Input2)
      {
         int   Value1;
         int   Value2;
         int   Result;

         // Convert the strings.
         Value1 = Int32.Parse(Input1);
         Value2 = Int32.Parse(Input2);

         // Perform the addition.
         Result = Value1 / Value2;

         // Output the result.
         return Result.ToString();
      }
   }

   public class MathCheckTest: TestCase
   {
      // The test class must include a constructor
      // that accepts a string as input.
      public MathCheckTest(String name) : base(name)
      {
      }

      // Test the add function using a simple example.
      public void TestAdd()
      {
         string   Expected = "5";
         string   Result = MathCheck.DoAdd("2", "3");
         Assert(Expected.Equals(Result));
      }

      // Test the subtract function using a simple example.
      public void TestSubtract()
      {
         string   Expected = "1";
         string   Result = MathCheck.DoSubtract("3", "2");
         Assert(Expected.Equals(Result));
      }

      // Test the multiply function using a simple example.
      public void TestMultiply()
      {
         string   Expected = "6";
         string   Result = MathCheck.DoMultiply("2", "3");
         Assert(Expected.Equals(Result));
      }

      // Test the divide function using a simple example. In
      // some cases you need multiple tests. This one performs
      // a normal divide.
      public void TestDivide1()
      {
         string   Expected = "2";
         string   Result = MathCheck.DoDivide("6", "3");
         Assert(Expected.Equals(Result));
      }

      // This second divide test checks for a proper divide by
      // zero response.
      public void TestDivide2()
      {
         string   Expected = "0";
         string   Result = MathCheck.DoDivide("6", "0");
         Assert(Expected.Equals(Result));
      }

      // You must define a suite of tests to perform.
      public static ITest Suite 
      {
         get 
         {
            return new TestSuite(typeof (MathCheckTest));
         }
      }
   }

   public class DivideByZeroTest: TestCase
   {
      // The test class must include a constructor
      // that accepts a string as input.
      public DivideByZeroTest(String name) : base(name)
      {
      }

      // Even if you only have one test in the suite, you
      // still need to define the test suite.
      public static ITest Suite 
      {
         get 
         {
            return new TestSuite(typeof (MathCheckTest));
         }
      }

      // Sometimes it pays to place a test in a separate
      // class so you can check just that functionality.
      public void TestDivideByZero()
      {
         string   Expected = "0";
         string   Result = MathCheck.DoDivide("6", "0");
         Assert(Expected.Equals(Result));
      }
   }
}

