import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ParametrosSistemaComponent } from './parametros-sistema.component';
import { ParametrosSistemaCadastroComponent } from './parametros-sistema-cadastro/parametros-sistema-cadastro.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { PartialsModule } from '../../partials/partials.module';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule, MatMenuModule, MatSelectModule, MatInputModule, MatTableModule, MatAutocompleteModule, MatRadioModule, MatIconModule, MatNativeDateModule, MatProgressBarModule, MatDatepickerModule, MatCardModule, MatPaginatorModule, MatSortModule, MatCheckboxModule, MatProgressSpinnerModule, MatSnackBarModule, MatExpansionModule, MatTabsModule, MatTooltipModule, MatDialogModule, MAT_DIALOG_DEFAULT_OPTIONS, MatPaginatorIntl, DateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE } from '@angular/material';
import { ModuleGuard } from '../../../core/auth';
import { InterceptService, HttpUtilsService, TypesUtilsService, LayoutUtilsService } from '../../../core/_base/crud';
import { CustomMatPaginatorIntl } from '../../../core/_config/custom-mat-paginator-int';
import { PickDateAdapter } from '../../../core/_config/custom-data-picker';
import { MomentDateAdapter, MAT_MOMENT_DATE_FORMATS, MAT_MOMENT_DATE_ADAPTER_OPTIONS } from '@angular/material-moment-adapter';
import { ParametroSistemaService } from '../../../core/parametrosistema';

const routes: Routes = [
	{
		path: '',
		component: ParametrosSistemaComponent,
		canActivate:[ModuleGuard],
		data: { moduleName: 'acessoParametrosSistema' },
		children: [
			{
				path: '',
				redirectTo: 'cadastro',
				pathMatch: 'full'
			},		
			{
				path: 'cadastro',
				component: ParametrosSistemaCadastroComponent,
			}
		]
	}
];

@NgModule({
  imports: [
    CommonModule,
    HttpClientModule,
    PartialsModule,
    RouterModule.forChild(routes),
    FormsModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatMenuModule,
    MatSelectModule,
    MatInputModule,
    MatTableModule,
    MatAutocompleteModule,
    MatRadioModule,
    MatIconModule,
    MatNativeDateModule,
    MatProgressBarModule,
    MatDatepickerModule,
    MatCardModule,
    MatPaginatorModule,
    MatSortModule,
    MatCheckboxModule,
    MatProgressSpinnerModule,
    MatSnackBarModule,
    MatExpansionModule,
    MatTabsModule,
    MatTooltipModule,
    MatDialogModule,
  ],
  providers: [
		ModuleGuard,
		InterceptService,
		{
        	provide: HTTP_INTERCEPTORS,
       	 	useClass: InterceptService,
			multi: true
		},
		{
			provide: MAT_DIALOG_DEFAULT_OPTIONS,
			useValue: {
				hasBackdrop: true,
				panelClass: 'kt-mat-dialog-container__wrapper',
				height: 'auto',
				width: '900px',
				
			}
		},
		{
		provide: MatPaginatorIntl, 
      		useClass: CustomMatPaginatorIntl		
		},
		{provide: DateAdapter, useClass: PickDateAdapter},
		{
			provide: DateAdapter,
			useClass: MomentDateAdapter,
			deps: [MAT_DATE_LOCALE, MAT_MOMENT_DATE_ADAPTER_OPTIONS]
		},
		{provide: MAT_DATE_FORMATS, useValue: MAT_MOMENT_DATE_FORMATS},
		{provide: MAT_DATE_LOCALE, useValue: 'pt-PT'},
		HttpUtilsService,
		TypesUtilsService,
		LayoutUtilsService,
		ParametroSistemaService
	],
  declarations: [ParametrosSistemaComponent, ParametrosSistemaCadastroComponent]
})
export class ParametrosSistemaModule { }
