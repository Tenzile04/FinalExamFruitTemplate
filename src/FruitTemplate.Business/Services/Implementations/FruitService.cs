using FruitTemplate.Business.Exceptions;
using FruitTemplate.Business.Extensions;
using FruitTemplate.Business.Services.Interfaces;
using FruitTemplate.Core.Models;
using FruitTemplate.Core.Repositories.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FruitTemplate.Business.Services.Implementations
{
    public class FruitService : IFruitService
    {
        private readonly IFruitRepository _fruitRepository;
        private readonly IWebHostEnvironment _env;

        public FruitService(IFruitRepository fruitRepository,IWebHostEnvironment env)
        {
            _fruitRepository = fruitRepository;
            _env = env;
        }
        public async Task Create(Fruit fruit)
        {
            if (fruit is null) throw new InvalidNotFoundException();
            if(fruit.ImageFile != null)
            {
                if (fruit.ImageFile.ContentType != "image/jpeg" && fruit.ImageFile.ContentType != "image/png")
                {
                    throw new InvalidContentTypeException("ImageFile", "ImageFile ContentType must be .png or .jpeg");
                }
                if (fruit.ImageFile.Length > 1048576)
                {
                    throw new InvalidImageSizeException("ImageFile", "ImageSize must be lower than 1048576 ");
                }
                fruit.ImageUrl = Helper.SaveFile(_env.WebRootPath, "uploads/fruits", fruit.ImageFile);
            }
            else
            {
                throw new InvalidImageFileException("ImageFile", "ImageFile is required");
            }
            fruit.CreatedDate = DateTime.UtcNow.AddHours(4);
            await _fruitRepository.CreateAsync(fruit);
            await _fruitRepository.CommitAsync();
        
        }

        public async Task Delete(int id)
        {
            if (id == null) throw new InvalidNotFoundException();
            var existFruit=await _fruitRepository.GetByIdAsync(x=>x.Id == id);
            
             _fruitRepository.Delete(existFruit);
            await _fruitRepository.CommitAsync();

        }

        public async Task<List<Fruit>> GetAll(Expression<Func<Fruit, bool>>? expression = null, params string[]? includes)
        {
            return await _fruitRepository.GetAllWhereAsync(expression, includes).ToListAsync();
        }

        public async Task<Fruit> GetById(Expression<Func<Fruit, bool>>? expression = null, params string[]? includes)
        {
            return await _fruitRepository.GetByIdAsync(expression, includes);
        }

        public async Task Update(Fruit fruit)
        {
            if(fruit == null) throw new InvalidNotFoundException();
            var existFruit = await _fruitRepository.GetByIdAsync(x => x.Id == fruit.Id);
            if (fruit.ImageFile != null)
            {
                if (fruit.ImageFile.ContentType != "image/jpeg" && fruit.ImageFile.ContentType != "image/png")
                {
                    throw new InvalidContentTypeException("ImageFile", "ImageFile ContentType must be .png or .jpeg");
                }
                if (fruit.ImageFile.Length > 1048576)
                {
                    throw new InvalidImageSizeException("ImageFile", "ImageSize must be lower than 1048576 ");
                }
                Helper.DeleteFile(_env.WebRootPath, "uploads/fruits", existFruit.ImageUrl);
               existFruit.ImageUrl = Helper.SaveFile(_env.WebRootPath, "uploads/fruits", fruit.ImageFile);
            }
            else
            {
                throw new InvalidImageFileException("ImageFile", "ImageFile is required");
            }
            existFruit.Name = fruit.Name;
            existFruit.Description = fruit.Description;
            existFruit.UpdatedDate = DateTime.UtcNow.AddHours(4);
            await _fruitRepository.CommitAsync();
        }
    }
}
