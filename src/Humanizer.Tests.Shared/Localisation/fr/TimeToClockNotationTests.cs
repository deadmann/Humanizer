﻿#if NET6_0_OR_GREATER

using System;
using Xunit;
using Humanizer.Localisation.TimeToClockNotation;
using Humanizer;

namespace Humanizer.Tests.Localisation.fr
{
    [UseCulture("fr")]
    public class TimeToClockNotationTests
    {
        [Theory]
        [InlineData(00, 00, "minuit")]
        [InlineData(01, 00, "une heure")]
        [InlineData(04, 00, "quatre heures")]
        [InlineData(05, 01, "cinq heures une")]
        [InlineData(06, 05, "six heures cinq")]
        [InlineData(07, 10, "sept heures dix")]
        [InlineData(08, 15, "huit heures et quart")]
        [InlineData(09, 20, "neuf heures vingt")]
        [InlineData(10, 25, "dix heures vingt-cinq")]
        [InlineData(11, 30, "onze heures et demie")]
        [InlineData(12, 00, "midi")]
        [InlineData(15, 35, "quinze heures trente-cinq")]
        [InlineData(16, 40, "dix-sept heures moins vingt")]
        [InlineData(17, 45, "dix-huit heures moins le quart")]
        [InlineData(18, 50, "dix-huit heures cinquante")]
        [InlineData(19, 55, "dix-neuf heures cinquante-cinq")]
        [InlineData(20, 59, "vingt heures cinquante-neuf")]
        public void ConvertToClockNotationTimeOnlyString(int hours, int minutes, string expectedResult)
        {
            var actualResult = new TimeOnly(hours, minutes).ToClockNotation();
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(00, 00, "minuit")]
        [InlineData(04, 00, "quatre heures")]
        [InlineData(05, 01, "cinq heures")]
        [InlineData(06, 05, "six heures cinq")]
        [InlineData(07, 10, "sept heures dix")]
        [InlineData(08, 15, "huit heures et quart")]
        [InlineData(09, 20, "neuf heures vingt")]
        [InlineData(10, 25, "dix heures vingt-cinq")]
        [InlineData(11, 30, "onze heures et demie")]
        [InlineData(12, 00, "midi")]
        [InlineData(13, 23, "treize heures vingt-cinq")]
        [InlineData(14, 32, "quatorze heures et demie")]
        [InlineData(15, 35, "quinze heures trente-cinq")]
        [InlineData(16, 40, "dix-sept heures moins vingt")]
        [InlineData(17, 45, "dix-huit heures moins le quart")]
        [InlineData(18, 50, "dix-huit heures cinquante")]
        [InlineData(19, 55, "dix-neuf heures cinquante-cinq")]
        [InlineData(20, 59, "vingt et une heures")]
        public void ConvertToRoundedClockNotationTimeOnlyString(int hours, int minutes, string expectedResult)
        {
            var actualResult = new TimeOnly(hours, minutes).ToClockNotation(ClockNotationRounding.NearestFiveMinutes);
            Assert.Equal(expectedResult, actualResult);
        }
    }
}

#endif
