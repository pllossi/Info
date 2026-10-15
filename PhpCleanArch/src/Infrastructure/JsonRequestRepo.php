<?php

namespace App\Infrastructure;

use App\Domain\Request;
use App\Domain\RequestsRepoInterface;
use RuntimeException;

class JsonRequestRepo implements RequestsRepoInterface{
    public function __construct(
        private string $filePath
    ){}
    /*
     * @return Request[];
     */
    public function findAll(): array{
        if(!file_exists($this->filePath)){
            throw new RuntimeException("File not found: {$this->filePath}");
        }
        $json = file_get_contents($this->filePath);
        $data = json_decode($json, true);
        $requests = [];
        foreach($data as $item){
            $requests[] = new Request(
                id: $item['id'],
                name: $item['titolo'],
                description: $item['descrizione'],
                autore: $item['autore'],
                data: $item['data']
            );
        }
        return $requests;
    }
}
