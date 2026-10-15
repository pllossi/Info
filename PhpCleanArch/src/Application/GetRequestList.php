<?php

namespace App\Application;

use App\Domain\RequestsRepoInterface;
use App\Infrastructure\JsonRequestRepo;
use App\Domain\Request;

class GetRequestList{
    public function __construct(
        private RequestsRepoInterface $repo
    ){}
    public function execute(): array{
        $req = $this->repo->findAll();
        usort($req, function (Request $r1, Request $r2) {
            return strcmp($r1->data, $r2->data);
        });
        return $req;
    }
}