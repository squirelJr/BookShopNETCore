
using Abstractions.DTO;
using System.Collections.Generic;

namespace Domain
{
 
        public class BooksInMemory
        {
            private readonly List<BookDTO> _BookList;

            public BooksInMemory()
            {
                _BookList = new List<BookDTO>()
            {
                new BookDTO()
                {
                    Id = 1,
                   Title = ".NET CORE Basics",
                   Author= "Sam Ruby, Dave Thomas, David Heinemeier Hansson",
                   Description="Rails is a full-stack, open source web framework that enables you to create full-featured, sophisticated web-based applications, but with a twist... A full Rails application probably has less total code than the XML you'd need to configure the same application in other frameworks. With this book you'll learn how to use \"ActiveRecord\" to connect business objects and database tables. No more painful object-relational mapping. Just create your business objects and let Rails do the rest. You'll learn how to use the \"Action Pack\" framework to route incoming requests and render pages using easy-to-write templates and components. See how to exploit the Rails service frameworks to send emails, implement web services, and create dynamic, user-centric web-pages using built-in Javascript and Ajax support. There are extensive chapters on testing, deployment, and scaling. " ,
                   IsActive =true
               
                },
                new BookDTO()
                {
                    Id = 2,
                    Title="Eloquent JavaScript, Third Edition",
                    Author="Marijn Haverbeke",
                    Description="JavaScript lies at the heart of almost every modern web application, from social apps like Twitter to browser-based game frameworks like Phaser and Babylon. Though simple for beginners to pick up and play with, JavaScript is a flexible, complex language that you can use to build full - scale applications.",
                     IsActive =true
                },
                new BookDTO()
                {
                    Id = 3,
                 Title="nderstanding ECMAScript 6",
                 Author="Nicholas C. Zakas",
                 Description="ECMAScript 6 represents the biggest update to the core of JavaScript in the history of the language. In Understanding ECMAScript 6, expert developer Nicholas C. Zakas provides a complete guide to the object types, syntax, and other exciting changes that ECMAScript 6 brings to JavaScript.",
                  IsActive =true
                },
                new BookDTO()
                {
                    Id = 4,
                    Title = "Speaking JavaScript",
                    Author = "Axel Rauschmaye",
                    Description="Like it or not, JavaScript is everywhere these days -from browser to server to mobile- and now you, too, need to learn the language or dive deeper than you have. This concise book guides you into and through JavaScript, written by a veteran programmer who once found himself in the same position.",
                    IsActive =true
                }
            };
            }

            public List<BookDTO> BookDtos => _BookList;
        }


    }