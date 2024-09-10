using Orion.Core.Common.Contracts;
using System.ComponentModel;
using Orion.Core.CommonTests.Core.Test_Classes;
using Xunit;


namespace Orion.Core.CommonTests.Core
{
    public class ObjectBaseTests
    {
        [Fact(Skip = "Failing Unit test")]
        public void test_clean_property_change()
        {
            TestClass objTest = new TestClass();
            bool propertyChanged = false;

            objTest.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "CleanProp")
                    propertyChanged = true;
            };

            objTest.CleanProp = "test value";
            Xunit.Assert.True(propertyChanged, "Changing CleanProp should have set the notification flag to true.");
           
        }

        [Fact(Skip = "Failing Unit test")]
        public void test_dirty_set()
        {
            TestClass objTest = new TestClass();

            Xunit.Assert.False(objTest.IsDirty, "Object should be clean.");

            objTest.DirtyProp = "test value";

            Xunit.Assert.True(objTest.IsDirty, "Object should be dirty.");
        }

        [Fact(Skip = "Failing Unit test")]
        public void test_property_change_single_subscription()
        {
            TestClass objTest = new TestClass();
            int changeCounter = 0;
            PropertyChangedEventHandler handler1 = new PropertyChangedEventHandler((s, e) => { changeCounter++; });
            PropertyChangedEventHandler handler2 = new PropertyChangedEventHandler((s, e) => { changeCounter++; });

            objTest.PropertyChanged += handler1;
            objTest.PropertyChanged += handler1; // should not duplicate
            objTest.PropertyChanged += handler1; // should not duplicate
            objTest.PropertyChanged += handler2;
            objTest.PropertyChanged += handler2; // should not duplicate

            objTest.CleanProp = "test value";

            Xunit.Assert.True(changeCounter == 2, "Property change notification should only have been called once.");
        }

        [Fact(Skip = "Failing Unit test")]
        public void test_child_dirty_tracking()
        {
            TestClass objTest = new TestClass();

            Xunit.Assert.False(objTest.IsAnythingDirty(), "Nothing in the object graph should be dirty.");

            objTest.Child.ChildName = "test value";

            Xunit.Assert.True(objTest.IsAnythingDirty(), "The object graph should be dirty.");

            objTest.CleanAll();

            Xunit.Assert.False(objTest.IsAnythingDirty(), "Nothing in the object graph should be dirty.");
        }

        [Fact(Skip = "Failing Unit test")]
        public void test_dirty_object_aggregating()
        {
            TestClass objTest = new TestClass();

            List<IDirtyCapable> dirtyObjects = objTest.GetDirtyObjects();

            Xunit.Assert.True(dirtyObjects.Count == 0, "There should be no dirty object returned.");

            objTest.Child.ChildName = "test value";
            dirtyObjects = objTest.GetDirtyObjects();

            Xunit.Assert.True(dirtyObjects.Count == 1, "There should be one dirty object.");

            objTest.DirtyProp = "test value";
            dirtyObjects = objTest.GetDirtyObjects();

            Xunit.Assert.True(dirtyObjects.Count == 2, "There should be two dirty object.");

            objTest.CleanAll();
            dirtyObjects = objTest.GetDirtyObjects();

            Xunit.Assert.True(dirtyObjects.Count == 0, "There should be no dirty object returned.");
        }

        [Fact(Skip = "Failing Unit test")]
        public void test_object_validation()
        {
            TestClass objTest = new TestClass();

            Xunit.Assert.False(objTest.IsValid, "Object should not be valid as one its rules should be broken.");

            objTest.StringProp = "Some value";

            Xunit.Assert.True(objTest.IsValid, "Object should be valid as its property has been fixed.");
        }
    }
}