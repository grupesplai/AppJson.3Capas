using System;
using TechTalk.SpecFlow;
using FluentAssertions;
using FileServer.Infrstructure.Repository_DAO_.RepositoryPaternEjemplo;

namespace StudentRepository.Behavior.Tests.Repositories
{
    [Binding]
    public class StudentRepositoryInsertSteps
    {
        StudentRepository repository = new StudentRepository();
        protected Student student;

        [Given(@"I have an Student without Id")]
        public void GivenIHaveAnStudentWithoutId()
        {
            student = new Student(new DateTime(1990,6,22));
        }
        
        [When(@"I run the method Insert of Student Repository")]
        public void WhenIRunTheMethodInsertOfStudentRepository()
        {
            repository.Insert(student);
        }
        
        [Then(@"the result Repository should return an Stuent with Id")]
        public void ThenTheResultRepositoryShouldReturnAnStuentWithId()
        {
            student.Id.Should().Be(1);
            student.Age.Should().Be(28);
        }
    }
}
