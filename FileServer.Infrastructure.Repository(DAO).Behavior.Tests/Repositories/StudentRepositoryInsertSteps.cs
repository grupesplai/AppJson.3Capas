using System;
using TechTalk.SpecFlow;
using FileServer.Infrastructure.Repository_DAO_;
using TechTalk.SpecFlow;
using FluentAssertions;
using FileServer.Infrstructure.Repository_DAO_.RepositoryPaternEjemplo;

namespace FileServer.Infrastructure.Repository_DAO_.Behavior.Tests.Repositories
{
    [Binding]
    public class StudentRepositoryInsertSteps
    {
        protected StudentRepository repository = new StudentRepository();
        protected Student student;
        [Given(@"I have an Student without Id")]
        public void GivenIHaveAnStudentWithoutId()
        {
            student = new Student();
        }
        
        [When(@"I run the method Insert of Student Repository")]
        public void WhenIRunTheMethodInsertOfStudentRepository()
        {
            student.Id = 1;
            student.Age = 28;
        }
        
        [Then(@"the result Repository should return an Stuent with Id")]
        public void ThenTheResultRepositoryShouldReturnAnStuentWithId()
        {
            student.Id.Should().Be(1);
        }
    }
}
