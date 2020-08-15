@echo Remover Servico
@setlocal enableextensions
@cd /d "%~dp0"

sc.exe stop "Loja Virtual"
sc.exe delete "Loja Virtual"