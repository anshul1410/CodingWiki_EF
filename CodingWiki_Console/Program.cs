﻿// See https://aka.ms/new-console-template for more information
using CodingWiki_DataAccess.Data;
using CodingWiki_DataAccess.Migrations;
using CodingWiki_Models.Models;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

//using (ApplicationDbContext context = new())
//{
//    context.Database.EnsureCreated();
//    if(context.Database.GetPendingMigrations().Count() > 0 )
//    {
//        context.Database.Migrate();
//    }
//}

//AddBook();
//GetAllBooks();

//void GetAllBooks()
//{
//    using var context = new ApplicationDbContext();
//    var books = context.Books.ToList();
//    foreach(var book in books)
//    {
//        Console.WriteLine(book.Title + " - " +book.ISBN);
//    }
//}

//void AddBook()
//{
//    Book book = new() { Title = "Knight and Day", ISBN = "215D5", Price = 19.03m, Publisher_Id = 1 };
//    using var context = new ApplicationDbContext();
//    var books = context.Books.Add(book);
//    context.SaveChanges();
//}