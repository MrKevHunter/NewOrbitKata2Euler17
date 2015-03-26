using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using Fixie;
using Should;

namespace Euler17
{
    public class CustomConvention : Convention
    {
        public CustomConvention()
        {
            Classes
                .NameEndsWith("Tests");

            Methods
                .Where(method => method.IsVoid());

            Parameters
                .Add<FromInputAttributes>();
        }

        private class FromInputAttributes : ParameterSource
        {
            public IEnumerable<object[]> GetParameters(MethodInfo method)
            {
                return method.GetCustomAttributes<InputAttribute>(true).Select(input => input.Parameters);
            }
        }
    }

    public class NumberToTextConverterTests
    {
        public void GivenTheNumber1WhenAskedReturnsOne()
        {
            new NumberConverter().Convert(1).ShouldEqual("One");
        }

        [Input(2, "Two")]
        [Input(3, "Three")]
        [Input(4, "Four")]
        [Input(5, "Five")]
        [Input(6, "Six")]
        [Input(7, "Seven")]
        [Input(8, "Eight")]
        [Input(9, "Nine")]
        [Input(10, "Ten")]
        [Input(11, "Eleven")]
        [Input(12, "Twelve")]
        [Input(13, "Thirteen")]
        [Input(14, "Fourteen")]
        [Input(15, "Fifteen")]
        [Input(16, "Sixteen")]
        [Input(17, "Seventeen")]
        [Input(18, "Eighteen")]
        [Input(19, "Nineteen")]
        [Input(20, "Twenty")]
        [Input(30, "Thirty")]
        [Input(40, "Forty")]
        [Input(50, "Fifty")]
        [Input(60, "Sixty")]
        [Input(70, "Seventy")]
        [Input(80, "Eighty")]
        [Input(90, "Ninety")]
        public void GivenTheNumber2WhenAskedReturnsTwo(int input, string output)
        {
            new NumberConverter().Convert(input).ShouldEqual(output);
        }

        public void GivenTheNumber21WhenAskedReturnsTwenty_One()
        {
            new NumberConverter().Convert(21).ToLower().ShouldEqual("Twenty One".ToLower());
        }

        public void GivenTheNumber28WhenAskedReturnsTwenty_Eight()
        {
            new NumberConverter().Convert(28).ToLower().ShouldEqual("Twenty Eight".ToLower());
        }

        public void GivenTheNumber100WhenAskedReturnsOne_Hundred()
        {
            new NumberConverter().Convert(100).ToLower().ShouldEqual("One Hundred".ToLower());
        }

        public void GivenTheNumber101WhenAskedReturnsOne_Hundred_And_One()
        {
            new NumberConverter().Convert(101).ToLower().ShouldEqual("One Hundred And One".ToLower());
        }

        public void GivenTheNumber927WhenAskedReturnsNine_Hundred_And_Twenty_Seven()
        {
            new NumberConverter().Convert(927).ToLower().ShouldEqual("Nine Hundred And Twenty Seven".ToLower());
        }

        public void GivenTheNumber970WhenAskedReturnsNine_Hundred_And_Seventy()
        {
            new NumberConverter().Convert(970).ToLower().ShouldEqual("Nine Hundred And Seventy".ToLower());
        }

        public void GivenTheNumber1000WhenAskedReturnsOne_Thousand()
        {
            new NumberConverter().Convert(1000).ToLower().ShouldEqual("One Thousand".ToLower());
        }

        public void GivenTheProblemCalculateTheSolution()
        {
            var numberConverter = new NumberConverter();
            var sb = new StringBuilder();
            for (var i = 1; i <= 1000; i++)
            {
                var convert = numberConverter.Convert(i);
                Trace.WriteLine(convert);
                sb.Append(convert.Replace(" ", ""));
            }

            Trace.WriteLine(sb.ToString());
            Trace.WriteLine(sb.Length);
        }
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class InputAttribute : Attribute
    {
        public InputAttribute(params object[] parameters)
        {
            Parameters = parameters;
        }

        public object[] Parameters { get; private set; }
    }
}