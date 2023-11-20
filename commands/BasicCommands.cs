using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using DSharpPlus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Botzy.other;
using System.Runtime.Remoting.Messaging;

namespace Botzy.commands
{
    public class BasicCommands : BaseCommandModule

    {
        #region Simple commands
        [Command("hello")]
        public async Task SayHelloCommand(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync($"Hello {ctx.User.Username}");
        }

        [Command("embed")]
        public async Task SendEmbedMessage(CommandContext ctx)
        {
            var embedMessage = new DiscordEmbedBuilder()
            {
                Title = "This is a title",
                Description = "This is a description",
                Color = DiscordColor.Blue,
            };
            await ctx.Channel.SendMessageAsync(embed: embedMessage);
        }
        #endregion
        #region Card Game
        [Command("cardgame")]
        public async Task CardGame(CommandContext ctx)
        {
            var userCard = new CardSystem();

            var userCardEmbed = new DiscordEmbedBuilder
            {
                Title = $"{ctx.User.Username}'s card is a {userCard.SelectedCard}",
                Color = DiscordColor.Lilac
            };

            await ctx.Channel.SendMessageAsync(embed: userCardEmbed);

            var botzyCard = new CardSystem();

            var botzyCardEmbed = new DiscordEmbedBuilder
            {
                Title = $"Botzy's card is a {botzyCard.SelectedCard}",
                Color = DiscordColor.Orange
            };

            await ctx.Channel.SendMessageAsync(embed: botzyCardEmbed);

            if (userCard.SelectedNumber > botzyCard.SelectedNumber)
            {
                var winMessage = new DiscordEmbedBuilder
                {
                    Title = $"{ctx.User.Username} won !",
                    Color = DiscordColor.Green
                };

                await ctx.Channel.SendMessageAsync(embed: winMessage);
            }

            else if (userCard.SelectedNumber < botzyCard.SelectedNumber)
            {
                var looseMessage = new DiscordEmbedBuilder
                {
                    Title = "Botzy won !",
                    Color = DiscordColor.Red
                };

                await ctx.Channel.SendMessageAsync(embed: looseMessage);
            }
            else
            {
                var tieMessage = new DiscordEmbedBuilder
                {
                    Title = "It's a tie !",
                    Color = DiscordColor.Black
                };

                await ctx.Channel.SendMessageAsync(embed: tieMessage);
            }

        }
            #endregion
            #region Calculations

            [Command("add")]
            public async Task Add(CommandContext ctx, int number1, int number2)
            {
                int result = number1 + number2;
                await ctx.Channel.SendMessageAsync(result.ToString());
            }

            [Command("subtract")]
            public async Task Subtract(CommandContext ctx, int number1, int number2)
            {
                int result = number1 - number2;
                await ctx.Channel.SendMessageAsync(result.ToString());
            }

            [Command("Multiply")]
            public async Task Multiply(CommandContext ctx, int number1, int number2)
            {
                int result = number1 * number2;
                await ctx.Channel.SendMessageAsync(result.ToString());
            }

            [Command("divide")]
            public async Task Divide(CommandContext ctx, int number1, int number2)
            {
                int result = number1 / number2;
                await ctx.Channel.SendMessageAsync(result.ToString());
            }
            #endregion
        }
    }