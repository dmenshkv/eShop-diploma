using System.Diagnostics.CodeAnalysis;
using Catalog.DataAccess.Contexts;
using Catalog.Entites.Common;
using Microsoft.EntityFrameworkCore;

namespace Catalog.DataAccess.Initializators
{
    [ExcludeFromCodeCoverage]
    public static class DbInitializer
    {
        public static async Task InitializeAsync(ApplicationDbContext context)
        {
            await context.Database.EnsureCreatedAsync();

            if (!context.Brands.Any())
            {
                await context.Brands.AddRangeAsync(GetPreconfiguredBrands());
                await context.SaveChangesAsync();
            }

            if (!context.Categories.Any())
            {
                await context.Categories.AddRangeAsync(GetPreconfiguredCategories());
                await context.SaveChangesAsync();
            }

            if (!context.Mechanics.Any())
            {
                await context.Mechanics.AddRangeAsync(GetPreconfiguredMechanics());
                await context.SaveChangesAsync();
            }

            if (!context.BoardGames.Any())
            {
                var brands = await GetBrandsAsync(context);
                var mechanics = await GetMechanicsAsync(context);
                var categories = await GetCategoriesAsync(context);

                await context.BoardGames.AddRangeAsync(GetPreconfiguredBoardGames(brands, mechanics, categories));
                await context.SaveChangesAsync();
            }
        }

        private static IEnumerable<Brand> GetPreconfiguredBrands()
        {
            return new List<Brand>()
            {
                new Brand()
                {
                    Name = "Cosmic Wimpout",
                    Country = "United States"
                },
                new Brand()
                {
                    Name = "Cakebread & Walton",
                    Country = "United Kingdom"
                },
                new Brand()
                {
                    Name = "Bethesda Softworks",
                    Country = "United States"
                },
                new Brand()
                {
                    Name = "Decipher, Inc.",
                    Country = "United States"
                },
                new Brand()
                {
                    Name = "The Game Crafter",
                    Country = "United States"
                }
            };
        }

        private static IEnumerable<Category> GetPreconfiguredCategories()
        {
            return new List<Category>()
            {
                new Category()
                {
                    Name = "Strategy"
                },
                new Category()
                {
                    Name = "Thematic"
                },
                new Category()
                {
                    Name = "Family"
                },
                new Category()
                {
                    Name = "Party Game"
                },
                new Category()
                {
                    Name = "Childrens Game"
                }
            };
        }

        private static IEnumerable<Mechanic> GetPreconfiguredMechanics()
        {
            return new List<Mechanic>()
            {
                new Mechanic()
                {
                    Name = "Area Control"
                },
                new Mechanic()
                {
                    Name = "Dice Rolling"
                },
                new Mechanic()
                {
                    Name = "Memory"
                },
                new Mechanic()
                {
                    Name = "Cooperative"
                },
                new Mechanic()
                {
                    Name = "Card"
                }
            };
        }

        private static IEnumerable<BoardGame> GetPreconfiguredBoardGames(List<Brand> brands, List<Mechanic> mechanics, List<Category> categories)
        {
            return new List<BoardGame>()
            {
                new BoardGame()
                {
                    Name = "10 Minute Heist: The Wizard's Tower",
                    Description = "In 10 Minute Heist: The Wizard's Tower, players take turns moving their pawns from room to room stealing items. Players compete for most paintings, artifacts, jewels, and fossils.",
                    Price = 9.55M,
                    PictureFileName = "10-minute-heist.png",
                    Slug = "10-minute-heist-the-wizard's-tower",
                    AvailableStock = 10,
                    BrandId = brands[0].Id,
                    Categories = new List<Category>()
                    {
                        categories.Find(f => f.Name == "Strategy")!,
                        categories.Find(f => f.Name == "Party Game")!
                    },
                    Mechanics = new List<Mechanic>()
                    {
                        mechanics.Find(f => f.Name == "Dice Rolling")!,
                        mechanics.Find(f => f.Name == "Card")!
                    }
                },
                new BoardGame()
                {
                    Name = "13 Days: The Cuban Missile Crisis",
                    Description = "13 Days: The Cuban Missile Crisis is a nail-biting, theme saturated two-player strategy game about the Cuban Missile Crisis. Your fate is determined by how well you deal with the inherent dilemmas of the game, and the conflict.",
                    Price = 20.50M,
                    PictureFileName = "13-days.png",
                    Slug = "13-days-the-cuban-missile-crisis",
                    AvailableStock = 10,
                    BrandId = brands[0].Id,
                    Categories = new List<Category>()
                    {
                        categories.Find(f => f.Name == "Strategy")!,
                        categories.Find(f => f.Name == "Thematic")!
                    },
                    Mechanics = new List<Mechanic>()
                    {
                        mechanics.Find(f => f.Name == "Area Control")!,
                        mechanics.Find(f => f.Name == "Card")!
                    }
                },
                new BoardGame()
                {
                    Name = "2 de Mayo",
                    Description = "2 de Mayo is an abstract game of the terrible incidents that took place in Madrid on May 2, 1808. On that date, civilians in Madrid and a few Spanish army units rebelled against the French occupation troops of Napoleon.",
                    Price = 50.35M,
                    PictureFileName = "2-de-mayo.png",
                    Slug = "2-de-mayo",
                    AvailableStock = 10,
                    BrandId = brands[0].Id,
                    Categories = new List<Category>()
                    {
                        categories.Find(f => f.Name == "Strategy")!,
                        categories.Find(f => f.Name == "Thematic")!
                    },
                    Mechanics = new List<Mechanic>()
                    {
                        mechanics.Find(f => f.Name == "Area Control")!,
                        mechanics.Find(f => f.Name == "Card")!
                    }
                },
                new BoardGame()
                {
                    Name = "4 Gods",
                    Description = "In 4 gods, you and your opponents simultaneously create a world's geography and religious landscape by placing tiles, incarnating prophets, and establishing legendary cities.",
                    Price = 29.99M,
                    PictureFileName = "4-gods.png",
                    Slug = "4-gods",
                    AvailableStock = 10,
                    BrandId = brands[1].Id,
                    Categories = new List<Category>()
                    {
                        categories.Find(f => f.Name == "Strategy")!
                    },
                    Mechanics = new List<Mechanic>()
                    {
                        mechanics.Find(f => f.Name == "Area Control")!,
                        mechanics.Find(f => f.Name == "Card")!
                    }
                },
                new BoardGame()
                {
                    Name = "Alone",
                    Description = "One of the players controls the Hero, a castaway spacefarer exploring an unknown map full of dangers, trying to complete missions, while up to 3 Evil Masterminds plot in the darkness, trying to kill them.",
                    Price = 40.59M,
                    PictureFileName = "alone.png",
                    Slug = "alone",
                    AvailableStock = 10,
                    BrandId = brands[1].Id,
                    Categories = new List<Category>()
                    {
                        categories.Find(f => f.Name == "Thematic")!
                    },
                    Mechanics = new List<Mechanic>()
                    {
                        mechanics.Find(f => f.Name == "Memory")!,
                        mechanics.Find(f => f.Name == "Cooperative")!
                    }
                },
                new BoardGame()
                {
                    Name = "5-Minute Marvel",
                    Description = "Choose a Marvel hero and team up with other players to defeat evil Villains, Minions and Goons in just five minutes.",
                    Price = 12,
                    PictureFileName = "5-minute-marvel.png",
                    Slug = "5-minute-marvel",
                    AvailableStock = 10,
                    BrandId = brands[1].Id,
                    Categories = new List<Category>()
                    {
                        categories.Find(f => f.Name == "Thematic")!,
                        categories.Find(f => f.Name == "Party Game")!,
                    },
                    Mechanics = new List<Mechanic>()
                    {
                        mechanics.Find(f => f.Name == "Memory")!,
                        mechanics.Find(f => f.Name == "Card")!
                    }
                },
                new BoardGame()
                {
                    Name = "Arkham Horror",
                    Description = "Arkham Horror is a cooperative adventure game themed around H.P Lovecraft's Cthulhu Mythos. Players can select from 16 unique playable investigator characters, each with unique abilities, and will square off against the diabolical servants of 8 Ancient Ones.",
                    Price = 29.39M,
                    PictureFileName = "arkham-horror.png",
                    Slug = "arkham-horror",
                    AvailableStock = 10,
                    BrandId = brands[2].Id,
                    Categories = new List<Category>()
                    {
                        categories.Find(f => f.Name == "Strategy")!,
                        categories.Find(f => f.Name == "Thematic")!
                    },
                    Mechanics = new List<Mechanic>()
                    {
                        mechanics.Find(f => f.Name == "Dice Rolling")!,
                        mechanics.Find(f => f.Name == "Memory")!,
                        mechanics.Find(f => f.Name == "Cooperative")!
                    }
                },
                new BoardGame()
                {
                    Name = "Alea Iacta Est",
                    Description = "Players take on the role of Caesar and compete for the most prestige points. The challenge is to intelligently allocate your eight rolled dice among the five buildings to acquire the fame you need to win the game.",
                    Price = 35M,
                    PictureFileName = "alea-iacta-est.png",
                    Slug = "alea-iacta-est",
                    AvailableStock = 10,
                    BrandId = brands[2].Id,
                    Categories = new List<Category>()
                    {
                        categories.Find(f => f.Name == "Party Game")!
                    },
                    Mechanics = new List<Mechanic>()
                    {
                        mechanics.Find(f => f.Name == "Dice Rolling")!,
                        mechanics.Find(f => f.Name == "Cooperative")!
                    }
                },
                new BoardGame()
                {
                    Name = "Epic Spell Wars of the Battle Wizards",
                    Description = "The game focuses primarily on creating spell combos to blast your foes into the afterlife. Combine spell cards into three-piece combos, creating hundreds of unique and devastating attacks. The chaos is limited only by your thirst for destruction!",
                    Price = 226,
                    PictureFileName = "epic-spell-wars.png",
                    Slug = "epic-spell-wars-of-the-battle-wizards",
                    AvailableStock = 10,
                    BrandId = brands[2].Id,
                    Categories = new List<Category>()
                    {
                        categories.Find(f => f.Name == "Strategy")!,
                        categories.Find(f => f.Name == "Party Game")!
                    },
                    Mechanics = new List<Mechanic>()
                    {
                        mechanics.Find(f => f.Name == "Dice Rolling")!,
                        mechanics.Find(f => f.Name == "Cooperative")!,
                        mechanics.Find(f => f.Name == "Card")!
                    }
                },
                new BoardGame()
                {
                    Name = "Codenames",
                    Description = "Codenames is a social word game with a simple premise and challenging game play.Two rival spymasters know the secret identities of 25 agents. Their teammates know the agents only by their codenames. The teams compete to see who can make contact with all of their agents first.",
                    Price = 9.79M,
                    PictureFileName = "codenames.png",
                    Slug = "codenames",
                    AvailableStock = 10,
                    BrandId = brands[3].Id,
                    Categories = new List<Category>()
                    {
                        categories.Find(f => f.Name == "Party Game")!
                    },
                    Mechanics = new List<Mechanic>()
                    {
                        mechanics.Find(f => f.Name == "Memory")!,
                        mechanics.Find(f => f.Name == "Cooperative")!
                    }
                },
                new BoardGame()
                {
                    Name = "Shadows in the Forest",
                    Description = "It's a fun board game that you play in the dark, and is a great gift for kids and adults who like board games and want a unique experience.",
                    Price = 14,
                    PictureFileName = "shadows-in-the-forest.png",
                    Slug = "shadows-in-the-forest",
                    AvailableStock = 10,
                    BrandId = brands[4].Id,
                    Categories = new List<Category>()
                    {
                        categories.Find(f => f.Name == "Childrens Game")!
                    },
                    Mechanics = new List<Mechanic>()
                    {
                        mechanics.Find(f => f.Name == "Memory")!
                    }
                },
                new BoardGame()
                {
                    Name = "Outfoxed",
                    Description = "In Outfoxed, you move around the board to gather clues, then use the special evidence scanner to rule out suspects.",
                    Price = 14,
                    PictureFileName = "outfoxed.png",
                    Slug = "outfoxed",
                    AvailableStock = 10,
                    BrandId = brands[4].Id,
                    Categories = new List<Category>()
                    {
                        categories.Find(f => f.Name == "Childrens Game")!
                    },
                    Mechanics = new List<Mechanic>()
                    {
                        mechanics.Find(f => f.Name == "Dice Rolling")!,
                        mechanics.Find(f => f.Name == "Card")!
                    }
                }
            };
        }

        private static async Task<List<Brand>> GetBrandsAsync(ApplicationDbContext context)
        {
            return await context.Brands.ToListAsync();
        }

        private static async Task<List<Mechanic>> GetMechanicsAsync(ApplicationDbContext context)
        {
            return await context.Mechanics.ToListAsync();
        }

        private static async Task<List<Category>> GetCategoriesAsync(ApplicationDbContext context)
        {
            return await context.Categories.ToListAsync();
        }
    }
}