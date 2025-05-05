using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]

    public class ViewerTests
    {
        [TestMethod]
        public void ShowResult_NoRealRoots_PrintsCorrectMessage()
        {
            // Arrange
            var equation = new QuadraticEquation { A = 1, B = 0, C = 1 }; // Discriminant < 0
            var viewer = new Viewer();
            using var sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            viewer.ShowResult(equation);

            // Assert
            var output = sw.ToString().Trim();
            Assert.AreEqual("No real roots exist.", output);
        }

        [TestMethod]
        public void ShowResult_OneRealRoot_PrintsCorrectMessage()
        {
            // Arrange
            var equation = new QuadraticEquation { A = 1, B = 2, C = 1 }; // Discriminant = 0
            var viewer = new Viewer();
            using var sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            viewer.ShowResult(equation);

            // Assert
            var output = sw.ToString().Trim();
            Assert.IsTrue(output.Contains("One root: x = -1"));
        }

        [TestMethod]
        public void ShowResult_TwoRealRoots_PrintsCorrectMessage()
        {
            // Arrange
            var equation = new QuadraticEquation { A = 1, B = -3, C = 2 }; // Discriminant > 0
            var viewer = new Viewer();
            using var sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            viewer.ShowResult(equation);

            // Assert
            var output = sw.ToString().Trim();
            Assert.IsTrue(output.Contains("Two roots: x1 = 2, x2 = 1") || output.Contains("Two roots: x1 = 1, x2 = 2"));
        }
    }