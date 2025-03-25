using System.Collections.Generic;
using UnityEngine;
using Neo4j.Driver;
using System.Threading.Tasks;
using System;

public class DatabaseManager{
    private static IDriver _driver;
    private static DatabaseManager databaseManager;
    private DatabaseManager(){}

    public static DatabaseManager GetDatabaseManager(){
        if (databaseManager == null){
            databaseManager = new();
            CreateConnetion();
        }
        return databaseManager;
    }

    private static void CreateConnetion(){
        var uri = "bolt://localhost:7687";
        var user = "neo4j";
        var password = "RoboticsLab2024!";
        
        Debug.Log("SONO QUI");

        try{
            Debug.Log("Connessione...");
            _driver = GraphDatabase.Driver(uri, AuthTokens.Basic(user, password));
            Debug.Log("Connessione al database Neo4j riuscita!");
        }catch (System.Exception ex){
            Debug.LogError($"Errore durante la connessione o l'esecuzione della query: {ex.Message}");
        }
    }

    public async void DestroyConnectionAsync(){
        if (_driver != null){
            await _driver.DisposeAsync();
        }
    }

    public async Task<List<Dictionary<string, object>>> ExecuteQueryAsync(string query, bool isWrite = true){
        var results = new List<Dictionary<string, object>>();

        if (_driver == null){
            return results;
        }

        try{  
            await using var session = _driver.AsyncSession(o => o.WithDatabase("neo4j"));        
            if (isWrite){
                await session.ExecuteWriteAsync(async tx =>{
                    var cursor = await tx.RunAsync(query);

                    while (await cursor.FetchAsync()){
                        var record = cursor.Current;
                        var row = new Dictionary<string, object>();

                        foreach (var key in record.Keys){
                            row[key] = record[key];
                        }

                        results.Add(row);
                    }
                });
            }else{
                await session.ExecuteReadAsync(async tx =>{
                    var cursor = await tx.RunAsync(query);

                    while (await cursor.FetchAsync()){
                        var record = cursor.Current;
                        var row = new Dictionary<string, object>();

                        foreach (var key in record.Keys){
                            row[key] = record[key];
                        }

                        results.Add(row);
                    }
                });
            }

        }catch (System.Exception ex){
            Debug.LogError($"Errore durante l'esecuzione della query: {ex.Message}");
        }

        return results;
    }

}
