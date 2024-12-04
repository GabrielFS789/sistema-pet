import {
  AfterViewInit,
  Component,
  inject,
  model,
  OnInit,
  ViewChild,
} from '@angular/core';
import { MaterialModule } from '../../../material/material.module';
import { MatTable, MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { RouterLink } from '@angular/router';
import { IRaca } from '../../../Interfaces/IRaca.interface';
import { RacaService } from '../raca.service';
import { DialogDeleteComponent } from '../../../core/components/dialogs/dialog-delete/dialog-delete.component';
import { MatDialog } from '@angular/material/dialog';
import { MatDialogModule } from '@angular/material/dialog';

@Component({
    selector: 'app-raca',
    imports: [MaterialModule, RouterLink, MatDialogModule],
    templateUrl: './raca.component.html',
    styleUrl: './raca.component.scss'
})
export class RacaComponent implements OnInit, AfterViewInit {
  displayedColumns: string[] = ['id', 'nome', 'opcoes'];
  dataSource: MatTableDataSource<IRaca> = new MatTableDataSource();
  racas: IRaca[] = [];
  #racaService: RacaService = inject(RacaService);
  selectedRacaForDelete: IRaca | undefined;
  readonly dialog = inject(MatDialog);

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  ngOnInit(): void {
    this.#racaService.getAll().subscribe();
    this.#racaService.racas$.subscribe((racas) => {
      this.dataSource.data = racas;
    });
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  deleteRaca(row: IRaca): void {
    const dialog = this.dialog.open(DialogDeleteComponent, {
      width: '250px',
      data: row,
      enterAnimationDuration: 500,
      exitAnimationDuration: 500,
    });

    dialog.afterClosed().subscribe((res) => {
      if (res !== undefined) {
        this.#racaService.deleteById(res.id).subscribe(() => {
          this.#racaService.racas$.subscribe((raca) => {
            this.dataSource.data = raca;
          });
        });
      }
    });
  }
}
