#!/bin/bash

if [ ! -f /etc/nginx/ssl/api.e-kadry.crt ]; then
    openssl genrsa -out "/etc/nginx/ssl/api.e-kadry.key" 2048
    openssl req -new -key "/etc/nginx/ssl/api.e-kadry.key" -out "/etc/nginx/ssl/api.e-kadry.csr" -subj "/CN=api.e-kadry/O=api.e-kadry/C=PL"
    openssl x509 -req -days 365 -in "/etc/nginx/ssl/api.e-kadry.csr" -signkey "/etc/nginx/ssl/api.e-kadry.key" -out "/etc/nginx/ssl/api.e-kadry.crt"
fi

if [ ! -f /etc/nginx/ssl/e-kadry.crt ]; then
    openssl genrsa -out "/etc/nginx/ssl/e-kadry.key" 2048
    openssl req -new -key "/etc/nginx/ssl/e-kadry.key" -out "/etc/nginx/ssl/e-kadry.csr" -subj "/CN=e-kadry/O=e-kadry/C=PL"
    openssl x509 -req -days 365 -in "/etc/nginx/ssl/e-kadry.csr" -signkey "/etc/nginx/ssl/e-kadry.key" -out "/etc/nginx/ssl/e-kadry.crt"
fi

nginx
