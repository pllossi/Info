<?php
require_once __DIR__ . '/Domain/Requests.php';
require_once __DIR__ . '/Domain/RequestsRepoInterface.php';
require_once __DIR__ . '/Infrastructure/JsonRequestRepo.php';
require_once __DIR__ . '/Application/GetRequestList.php';

use App\Infrastructure\JsonRequestRepo;
use App\Application\GetRequestList;

$datapath = __DIR__ . '/Infrastructure/data.json';
$repo = new JsonRequestRepo($datapath);

$usecase = new GetRequestList($repo);
$richieste = $usecase->execute();
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
                    <h3><?= nl2br(htmlspecialchars($richiesta->name)) ?></h3>
                    <p><?= nl2br(htmlspecialchars($richiesta->description)) ?></p>
                    <div class="meta">
                        <strong>Inviato da:</strong> <?= nl2br(htmlspecialchars($richiesta->autore)) ?><br>
                        <strong>Data:</strong> <?= nl2br(htmlspecialchars($richiesta->data)) ?>
                    </div>
                </div>
            <?php endforeach; ?>
        <?php endif; ?>
    </div>
</body>
</html>
