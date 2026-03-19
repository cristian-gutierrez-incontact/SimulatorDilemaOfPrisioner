// See https://aka.ms/new-console-template for more information
using ServerDilemaDelPrisioner;
using ServerDilemaDelPrisioner.Strategies;
using ServerDilemaDelPrisioner.Strategies.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

Console.WriteLine("🎯 PRISONER'S DILEMMA SIMULATION");
Console.WriteLine("=================================\n");

List<IStrategy> strategies = new List<IStrategy>();
strategies.Add(new GenerousTitForTat() { Name = "GenerousTitForTat1" });
strategies.Add(new GenerousTitForTat() { Name = "GenerousTitForTat2" });
strategies.Add(new Grudger() { Name = "Grudger1" });
strategies.Add(new Grudger() { Name = "Grudger2" });
strategies.Add(new OverlyForgiving() { Name = "OverlyForgiving1" });
strategies.Add(new OverlyForgiving() { Name = "OverlyForgiving2" });
strategies.Add(new Pavlov() { Name = "Pavlov1" });
strategies.Add(new Pavlov() { Name = "Pavlov2" });
strategies.Add(new RandomStrategy() { Name = "RandomStrategy1" });
strategies.Add(new RandomStrategy() { Name = "RandomStrategy2" });
strategies.Add(new SelfDestructive() { Name = "SelfDestructive1" });
strategies.Add(new SelfDestructive() { Name = "SelfDestructive2" });
strategies.Add(new SpitefulRandom() { Name = "SpitefulRandom1" });
strategies.Add(new SpitefulRandom() { Name = "SpitefulRandom2" });
strategies.Add(new SuspiciousTitForTat() { Name = "SuspiciousTitForTat1" });
strategies.Add(new SuspiciousTitForTat() { Name = "SuspiciousTitForTat2" });
strategies.Add(new TitForTat() { Name = "TitForTat1" });
strategies.Add(new TitForTat() { Name = "TitForTat2" });
strategies.Add(new Bernardo() { Name = "Bernardo1" });
strategies.Add(new Bernardo() { Name = "Bernardo2" });
strategies.Add(new GonzaloStrat() { Name = "GonzaloStrat1" });
strategies.Add(new GonzaloStrat() { Name = "GonzaloStrat2" });
strategies.Add(new AlvaroR() { Name = "AlvaroR1" });
strategies.Add(new AlvaroR() { Name = "AlvaroR2" });
strategies.Add(new AlvaroT() { Name = "AlvaroT1" });
strategies.Add(new AlvaroT() { Name = "AlvaroT2" });
strategies.Add(new Jesus() { Name = "Jesus1" });
strategies.Add(new Jesus() { Name = "Jesus2" });
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