<?php

$jsonPos = __DIR__ . "/data.json";

if (!file_exists($jsonPos)) {
    die("File not found at $jsonPos");
}

$json = file_get_contents($jsonPos);
$richieste = json_decode($json, true);

if ($richieste === null) {
    die("Error decoding JSON");
}
?>

<!DOCTYPE html>
<html lang="it">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Banca Richieste</title>
    <link rel="stylesheet" href="style.css">
</head>
<body>
    <div class="container">
        <h1>Bacheca Richieste Assistenza</h1>

        <?php if (empty($richieste)): ?>
            <p>Nessuna richiesta presente in bacheca.</p>
        <?php else: ?>
            <?php foreach ($richieste as $richiesta): ?>
                <div class="card">
                    <h3><?= nl2br(htmlspecialchars($richiesta['titolo'])) ?></h3>
                    <p><?= nl2br(htmlspecialchars($richiesta['descrizione'])) ?></p>
                    <div class="meta">
                        <strong>Inviato da:</strong> <?= nl2br(htmlspecialchars($richiesta['autore'])) ?><br>
                        <strong>Data:</strong> <?= nl2br(htmlspecialchars($richiesta['data'])) ?>
                    </div>
                </div>
            <?php endforeach; ?>
        <?php endif; ?>
    </div>
</body>
</html>
