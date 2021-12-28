using UI;

/*
This program will be able to be loaded with new questions/answers and generate different subjects.
Each subject will have a concept walk trainer that list all of the notes of the subject, the user can review.
Each subject will then have a test that asks questions with one word answers, each concept should have at least 
two different questions, ideally three.Not all questions will be asked each test, but all concepts should be.
*/
Console.WriteLine("Welcome to the Study Terms Trainer!\n");
MenuFactory.GetMenu("main").Start();