<?php
namespace App\Domain;

readonly class Request{
    public function __construct(
        public int $id,
        public string $name,
        public string $description,
        public string $autore,
        public string $data,
    ) {}
}
