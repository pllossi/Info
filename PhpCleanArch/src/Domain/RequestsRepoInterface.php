<?php

namespace App\Domain;

interface RequestsRepoInterface{
    /*
     * @return Request[];
     */
    public function findAll(): array;
}