using Moq;
using MyRestfullApp.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRestfullApp.Tests
{
    //Now we have only one entity called User, but if we have more, we can create an interface called IIdentifiable which exposes the property ID
    public class MockDbSet<TEntity> : Mock<DbSet<TEntity>> where TEntity : User
    {
        private int IdentityCounter = 0;
        public MockDbSet(List<TEntity> dataSource = null)
        {
            var data = (dataSource ?? new List<TEntity>());
            var queryable = data.AsQueryable();

            this.As<IQueryable<TEntity>>().Setup(e => e.Provider).Returns(queryable.Provider);
            this.As<IQueryable<TEntity>>().Setup(e => e.Expression).Returns(queryable.Expression);
            this.As<IQueryable<TEntity>>().Setup(e => e.ElementType).Returns(queryable.ElementType);
            this.As<IQueryable<TEntity>>().Setup(e => e.GetEnumerator()).Returns(() => queryable.GetEnumerator());

            this.Setup(_ => _.Add(It.IsAny<TEntity>())).Returns((TEntity arg) => {
                IdentityCounter++;
                arg.Id = IdentityCounter;
                data.Add(arg);
                return arg;
            });

            this.Setup(m => m.Find(It.IsAny<object[]>()))
                    .Returns<object[]>(ids => data.FirstOrDefault(d => d.Id == (int)ids[0]));

            this.Setup(m => m.Remove(It.IsAny<TEntity>()))
                   .Returns((TEntity arg) => {
                       data.Remove(arg);
                       return arg;
                   });

        }
    }
}
