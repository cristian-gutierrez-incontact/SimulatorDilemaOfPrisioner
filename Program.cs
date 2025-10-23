// See https://aka.ms/new-console-template for more information
using ServerDilemaDelPrisioner.Strategies.Base;
using ServerDilemaDelPrisioner.Strategies;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ServerDilemaDelPrisioner;

Console.WriteLine("🎯 PRISONER'S DILEMMA SIMULATION");
Console.WriteLine("=================================\n");

List<IStrategy> strategies = new List<IStrategy>();
strategies.Add(new Alternator("Alternator1"));
strategies.Add(new Alternator("Alternator2"));
strategies.Add(new AlwaysColaborate("AlwaysColaborate1"));
strategies.Add(new AlwaysColaborate("AlwaysColaborate2"));
strategies.Add(new AlwaysNoncooperation("AlwaysNoncooperation1"));
strategies.Add(new AlwaysNoncooperation("AlwaysNoncooperation2"));
strategies.Add(new GenerousTitForTat("GenerousTitForTat1"));
strategies.Add(new GenerousTitForTat("GenerousTitForTat2"));
strategies.Add(new Grudger("Grudger1"));
strategies.Add(new Grudger("Grudger2"));
strategies.Add(new OverlyForgiving("OverlyForgiving1"));
strategies.Add(new OverlyForgiving("OverlyForgiving2"));
strategies.Add(new Pavlov("Pavlov1"));
strategies.Add(new Pavlov("Pavlov2"));
strategies.Add(new RandomStrategy("RandomStrategy1"));
strategies.Add(new RandomStrategy("RandomStrategy2"));
strategies.Add(new SelfDestructive("SelfDestructive1"));
strategies.Add(new SelfDestructive("SelfDestructive2"));
strategies.Add(new SpitefulRandom("SpitefulRandom1"));
strategies.Add(new SpitefulRandom("SpitefulRandom2"));
strategies.Add(new SuspiciousTitForTat("SuspiciousTitForTat1"));
strategies.Add(new SuspiciousTitForTat("SuspiciousTitForTat2"));
strategies.Add(new TitForTat("TitForTat1"));
strategies.Add(new TitForTat("TitForTat2"));
strategies.Add(new TitForTwoTats("TitForTwoTats1"));
strategies.Add(new TitForTwoTats("TitForTwoTats2"));
strategies.Add(new TriggerHappy("TriggerHappy1"));
strategies.Add(new TriggerHappy("TriggerHappy2"));
strategies.Add(new WorstOfBothWorlds("WorstOfBothWorlds1"));
strategies.Add(new WorstOfBothWorlds("WorstOfBothWorlds2"));

int setsPerMatch = 300;

MatchManager matchManager = new MatchManager(strategies, setsPerMatch);
matchManager.CreateTournament();
matchManager.PlayAllMatches();
Dictionary<string, int> totalScores = matchManager.GetTotalScores();
var sortedScores = totalScores.OrderByDescending(x => x.Value);

Console.WriteLine("📊 FINAL TOURNAMENT RESULTS");
Console.WriteLine("============================\n");

int rank = 1;
foreach (var kvp in sortedScores)
{
    Console.WriteLine($"{rank}. {kvp.Key}: {kvp.Value} points");
    rank++;
}

File.WriteAllLines("AllSets.txt", matchManager.GetAllSetsIntoTournament().ToArray());
File.WriteAllLines("ResumeMatches.txt", matchManager.GetMatchResults().ToArray());
Console.ReadLine();