# Esercizi svolti a casa e a scuola in C# 
Esercizi svolti a casa e a scuola mediante uso di WPF (Windows Presentation Foundation), .NET MAUI, .NET 8 durante l'anno 2025/2026 usando l'OOP e successivamente la struttura di programmazione CLEAN

## I vari esercizi
### Noleggio
#### Testo del problema 
Vuoi scrivere un programma per gestire un sistema di noleggio di veicoli per una compagnia chiamata "Global Mobility". Il sistema deve essere in grado di gestire diversi tipi di veicoli, come automobili, motociclette e biciclette.
Il sistema deve soddisfare i seguenti requisiti:
Tutti i veicoli devono avere un prezzo per giorno, un numero di targa e un metodo per calcolare il costo totale del noleggio in base al numero di giorni.
Tutti i veicoli, indipendentemente dal tipo, devono essere in grado di stampare una descrizione dettagliata di sé stessi che includa tutte le loro informazioni specifiche.
in particolare
Automobili: devono avere un attributo aggiuntivo per il numero di posti.
Motociclette: devono avere un attributo aggiuntivo per il tipo di casco (integrale, jet, ecc.).
Biciclette: non hanno attributi aggiuntivi, ma il loro calcolo del costo totale deve prevedere uno sconto del 10% se il noleggio dura più di 7 giorni.
Gestione del noleggio: il programma deve essere in grado di gestire il noleggio di qualsiasi veicolo, calcolare il costo e mostrare la loro descrizione.
#### Principio di soluzione
Si inizia con una classe di tipo abstract Veicolo dove noi abbiamo i dati che sono in comune con tutti i 3 tipi di veicolo, che poi si specializzano. Nella parte del WPF abbiamo la classe GestoreNoleggio.cs che si interfaccia con la libreria e ci permette di controllare i vari dati e di scriverli in memoria
### TestNoleggio
#### Testo del problema
Testare la libreria di Noleggio
### Gestione Animali Domestici
#### Testo del problema
Si vuole realizzare un piccolo sistema software per aiutare la Sig.ra Maria a gestire i suoi animali domestici Moxa (cane) e Petra (gatto).
Tutti gli animali devono avere un nome e per ogni animale deve essere possibile  memorizzare le visite veterinarie.
Deve essere possibile visualizzare tutte le visite effettuate oppure l'ultima vista effettuata e per ogni animale deve essere memorizzato l'alimento preferito ed il gioco preferito. Nel caso di Moxa si vuole memorizzare anche il masticativo preferito.
#### Richieste Particolari
- diagramma dei casi d'uso
