// using System;
// using System.Collections.Generic;
// using ViewInjection.Models;

// namespace pitch_app.Model.Services
// {
//     public interface IInningService
//     {
//         IEmumerable<Inning> List();
//     }
//     public class  InningService : IInningService
//     {
//         public IEnumerable<Inning> List()
//         {
//                 return new List<Inning>
//                 {
//                     new Inning{ Number = 1, Top=true},
//                     new Inning{ Number = 1, Top=false},
//                     new Inning{ Number = 2, Top=true}
//                     new Inning{ Number = 2, Top=false}
//                 }
//         }

//     }
// }