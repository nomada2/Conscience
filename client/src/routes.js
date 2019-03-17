import React from 'react';
import { Route, Switch } from 'react-router-dom';

import MapPage from './components/map/MapPage';
import PlotsPage from './components/plots/PlotsPage';
import PlotDetailPage from './components/plots/PlotDetailPage';
import PlotEditPage from './components/plots/PlotEditPage';
import CharactersPage from './components/characters/CharactersPage';
import CharacterDetailPage from './components/characters/CharacterDetailPage';
import CharacterEditPage from './components/characters/CharacterEditPage';
import CharacterAssignPage from './components/characters/CharacterAssignPage';
import BehaviourPage from './components/behaviour/BehaviourPage';
import HostStatsPage from './components/behaviour/HostStatsPage';
import MaintenancePage from './components/maintenance/MaintenancePage';
import MaintenanceDetailPage from './components/maintenance/MaintenanceDetailPage';
import SecurityPage from './components/security/SecurityPage';
import EmployeeDetailPage from './components/security/EmployeeDetailPage';
import HostDetailPage from './components/security/HostDetailPage';
import Notifications from './components/notifications/Notifications';
import BulkImportPage from './components/bulk-import/BulkImportPage';
import CoreMemoriesPage from './components/core-memories/CoreMemoriesPage';
import NotFound from './components/common/NotFound';

const Routes = () =>
  <Switch>
    <Route path="/" exact component={PlotsPage} />
    <Route path="/map" component={MapPage} />
    <Route path="/plot-detail/:plotId" component={PlotDetailPage} />
    <Route path="/plot-edit/:plotId" component={PlotEditPage} />
    <Route path="/characters" component={CharactersPage} />
    <Route path="/character-detail/:characterId" component={CharacterDetailPage} />
    <Route path="/character-edit/:characterId" component={CharacterEditPage} />
    <Route path="/character-assign/:characterId" component={CharacterAssignPage} />
    <Route path="/behaviour" component={BehaviourPage} />
    <Route path="/behaviour-detail/:hostId" component={HostStatsPage} />
    <Route path="/maintenance" component={MaintenancePage} />
    <Route path="/maintenance-detail/:hostId" component={MaintenanceDetailPage} />
    <Route path="/security" exact component={SecurityPage} />
    <Route path="/security-employee/:employeeId" component={EmployeeDetailPage} />
    <Route path="/security-host/:hostId" component={HostDetailPage} />
    <Route path="/notifications" exact component={Notifications} />
    <Route path="/bulk-import" component={BulkImportPage} />
    <Route path="/core-memories" component={CoreMemoriesPage} />
    <Route component={NotFound} />
  </Switch>;

export default Routes;
