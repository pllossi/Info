<!DOCTYPE html>
<html lang="it">
<head>
    <meta charset="UTF-8">
    <title>Lezione 2 PHP</title>
    <link rel="stylesheet" href="style.css">
</head>
<body>
    <h1>Lezione 2 PHP</h1>
    <div class="info">
        <p>Versione PHP: <?php echo phpversion(); ?></p>
        <p>Nome del server: <?php echo $_SERVER['SERVER_NAME']; ?></p>
        <p>Sistema operativo: <?php echo PHP_OS; ?></p>
        <p>Ora del server: <?php echo date('Y-m-d H:i:s'); ?></p>
    </div>
    <h2>Prova il Form</h2>
    <form method="post" action="">
        <label for="nome">Nome:</label>
        <input type="text" id="nome" name="nome" required>
        <br>
        <input type="submit" value="Invia">
    </form>
    <?php
    if(isset($_POST['nome'])) {
        $nome = htmlspecialchars($_POST['nome']);
        echo "<div class='result'>Ciao, <strong>$nome!</strong></div>";
    }
    ?>
</body>
</html>