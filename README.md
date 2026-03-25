# WPF + Clean Architecture + 모듈 로딩 예시

이 예시는 **메인 WPF 프로젝트가 외부 모듈(DLL)들을 로드**하고,
각 모듈은 **Clean Architecture (Domain / Application / Infrastructure / Presentation)** 로 구성되는 구조를 보여줍니다.

## 폴더 구조

```text
src/
 ├─ BuildingBlocks/
 │   └─ Module.Abstractions/
 │       ├─ IModule.cs
 │       └─ IModuleCatalog.cs
 │
 ├─ MainHost/
 │   ├─ MainHost.Presentation.Wpf/
 │   │   ├─ App.xaml
 │   │   ├─ App.xaml.cs
 │   │   ├─ MainWindow.xaml
 │   │   └─ MainWindowViewModel.cs
 │   ├─ MainHost.Application/
 │   │   └─ ModuleCatalog.cs
 │   └─ MainHost.Infrastructure/
 │       └─ FolderModuleLoader.cs
 │
 └─ Modules/
     └─ SampleSales/
         ├─ SampleSales.Domain/
         │   └─ Entities/Order.cs
         ├─ SampleSales.Application/
         │   └─ Services/GetOrdersQueryService.cs
         ├─ SampleSales.Infrastructure/
         │   └─ Persistence/InMemoryOrderRepository.cs
         └─ SampleSales.Presentation.Wpf/
             ├─ SampleSalesModule.cs
             └─ Views/SalesDashboardView.xaml
```

## 설계 포인트

1. **MainHost는 모듈 계약(Interface)만 의존**합니다.
2. 모듈은 `IModule`을 구현하여 자신의 View/서비스 등록 로직을 제공합니다.
3. MainHost.Infrastructure의 `FolderModuleLoader`가 `Modules` 폴더를 스캔해 모듈을 동적으로 로드합니다.
4. 각 모듈 내부는 Clean Architecture 레이어로 분리합니다.
   - Domain: 엔티티/비즈니스 규칙
   - Application: 유스케이스/서비스
   - Infrastructure: DB, 파일, 외부 API 구현체
   - Presentation: View, ViewModel, Module Bootstrap

## 실제 프로젝트에서 다음을 추가하세요

- DI 컨테이너 (Microsoft.Extensions.DependencyInjection)
- Prism 또는 CommunityToolkit.Mvvm
- 모듈 버전/의존성 관리
- 모듈 서명 검증(보안)
- 공통 이벤트 버스(MediatR 또는 메시징)

