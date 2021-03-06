﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using eClinic.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace eClinic
{
    public class Program
    {
        private static async Task<Doctor> GetDoctor()
        {
            Doctor student = null;
            using (var context = new ApplicationDbContext())
            {
                Console.WriteLine("Start GetStudent...");
                student = await (context.Doctor.Where(s => s.DoctorPesel == "80128462129")
                    .FirstOrDefaultAsync<Doctor>());
                Console.WriteLine("Koniec GetStudent...");
                Console.WriteLine(student.DoctorPesel + " " + student.FirstName
                    + " " + student.LastName);
            }
            return student; //tutaj student jest obiektem (krotką) zwracanym przez zadanie
        }
        public static void AsyncQueryAndSave()
        {
            var student = GetDoctor(); //zwraca zadanie (task) zwracające obiekt typu Student
            Console.WriteLine("Można wykonywać cokolwiek do czasu wczytania studenta..");
            student.Wait();
            //student.Result.Kierunek = "chemia";
            //var studentSave = SaveStudent(student.Result);
            //Console.WriteLine(" Można wykonywać cokolwiek do czasu zapisania studenta..");
            //studentSave.Wait();
        }
        public static void Main(string[] args)
        {
            //AsyncQueryAndSave();
            CreateWebHostBuilder(args).Run();
        }

        public static IWebHost CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder()
                .UseStartup<Startup>()
                .Build();
        }
    }
}
